
using DungeonFinderDomain.Interface.Repository;
using DungeonFinderDomain.Interface.Service;
using DungeonFinderDomain.Model.Entities;
using DungeonFinderDomain.Model.Requests;
using DungeonFinderDomain.Model.Response;

namespace DungeonFinderDomain.Services
{
    public class MesaService : IMesaService
    {
        private readonly IMesaRepository _mesaRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public MesaService(IMesaRepository mesaRepository, IJogadorRepository jogadorRepository)
        {
            _mesaRepository = mesaRepository;
            _jogadorRepository = jogadorRepository; 
        }

        public BaseResponse createJogadorNaMesa(JogadorNaMesaRequest request)
        {
            BaseResponse response = Validacoes(request);

            if (response.ErrorCode != 0) return response;

            return _mesaRepository.insertJogadorNaMesa(request);

        }
        public BaseResponse RemoveJogadorDaMesa(JogadorNaMesaRequest request)
        {
            BaseResponse response = Validacoes(request);

            if (response.ErrorCode != 0) return response;
        
            return _mesaRepository.RemoveJogadorDaMesa(request);
        }
        public BaseResponse createMesa(MesaCreateRequest request)
        {
            return _mesaRepository.createMesa(request);
        }
        public ListResponse<JogadorNaMesaResponse> getJogadoresNaMesa(int idMesa)
        {
            return _mesaRepository.getJogadoresNaMesa(idMesa);
        }
        public GenericResponse<MesaResponse> getMesaDetails(int mesaId)
        {
            return _mesaRepository.getMesaDetails(mesaId);
        }
        public ListResponse<MesaResponse> getMesas(MesaRequest request)
        {
            return _mesaRepository.getMesas(request);
        }
        public BaseResponse updateMesa(UpdateMesa request)
        {
            JogadorNaMesaRequest update = new JogadorNaMesaRequest();
            update.idMesa = request.IdMesa;
            update.idJogador = 0;

            BaseResponse response = MesaValida(update);

            if (response.ErrorCode != 0)
            {
                return response;
            }
            return _mesaRepository.updateMesa(request);
        }

        //TODO Colocar em metodos separados
        private BaseResponse MesaValida(JogadorNaMesaRequest request)
        {
            GenericResponse<MesaResponse> response = _mesaRepository.getMesaDetails(request.idMesa) ;    


            if (response.BaseResponse.ErrorCode != 0)
            {
                response.BaseResponse.Message = "Mesa não existe!";
            }
            else if (!response.Response.isAtivo)
            {
                response.BaseResponse.ErrorCode = 400;
                response.BaseResponse.Message = "A mesa está inativa!";
            }
            else if(response.Response.IdMestre == request.idJogador)
            {
                response.BaseResponse.ErrorCode = 400;
                response.BaseResponse.Message = "Jogador é o mestre da mesa!";
            }
            return response.BaseResponse;
        }
        private bool JogadorPertenceMesa(JogadorNaMesaRequest request)
        {
            var Jogadores = _mesaRepository.getJogadoresNaMesa(request.idMesa);

            foreach(var jogador in Jogadores.Items)
            {
                if (jogador.idJogador == request.idJogador) return true;
            }
            return false;
        }
        private bool JogadorExiste(int idJogador)
        {
            var jogador = _jogadorRepository.getJogadorById(idJogador);

            if(jogador.BaseResponse.ErrorCode != 0) return false;

            return true;
        }
        private BaseResponse Validacoes(JogadorNaMesaRequest request)
        {
            BaseResponse response = MesaValida(request);

            if (response.ErrorCode != 0)
            {
                return response;
            }
            if (JogadorPertenceMesa(request))
            {
                response.ErrorCode = 400;
                response.Message = "Jogador já pertence a mesa";
                return response;
            }
            if (!JogadorExiste(request.idJogador))
            {
                response.ErrorCode = 400;
                response.Message = "Jogador não está cadastrado";
                return response;
            }
            return response;
        }


    }
}
