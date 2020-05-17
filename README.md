# Telefonia

Api que busca, cadastra, deleta e altera planos de Operadoras telefônicas.

#Lista de end point

GET: https://{URL}/api/
  Busca todos os planos disponíveis
  
GET: https://{URL}/api/{ddd}/tipo/{tipo} 
  Busca planos disponíveis filtrados por ddd e tipo de plano
  [ 0 - Controle | 1 - Pós | 2 - Pré]
  
GET: https://{URL}/api/{ddd}/operadora/{operadora} 
  Busca planos disponíveis filtrados por ddd e operadora
  operadora : nome da operadora Ex.: claro, oi ,tim
  
 GET: https://{URL}/api/{ddd}/plano/{plano} 
  Busca planos disponíveis filtrados por ddd e plano
  plano : nome do plano Ex.: PREZAO30,VIVO20

POST: https://{URL}/api/
  Adiciona um novo plano

PUT: https://{URL}/api/{id plano}
  Altera um plano pelo ID

DELETE: https://{URL}/api/{id plano}
  Deleta um plano pelo ID
  
#Exemplos de requisições
https://www.getpostman.com/collections/3f4aa5f14abdbfe55b43



