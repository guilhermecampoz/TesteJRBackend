# Reflexão sobre o Teste

1. Qual foi a decisão técnica mais relevante que você tomou durante o teste? Por quê?

A descisão técnica mais importante foi a seperação dos métodos da Model "Tarefa" criando a camada de services para concentrar a lógica pesada e deixar tanto a Model quanto o Controller limpos e com responsabilidades bem definidas. Criei também outra camada para simular a persistência para não poluir o service também.

2. Tem alguma parte do código que você não ficou satisfeito? O que faria diferente com mais tempo?
    
Não fiquei exatamente satisfeito com a forma que fiz para simular a persistência, com mais tempo eu adicionaria o Entity Framework e simularia a utilização dele usando o provider InMemory pra deixar essa simulação mais próxima de um cenário real, principalmente considerando que a stack da empresa utiliza EF.

3. Se fosse necessário adicionar um campo "prazo de entrega" na tarefa, o que precisaria mudar no projeto?

Seria necessário adicionar uma nova propriedade na Model, e na DTO, ajustar o método de atualizar tarefa para permitir a alteração desse campo também.

4. Ferramentas utilizadas:
    - [X] Usei IA (qual? como?) - ChatGPT para orientação do padrão result
    - [ ] Documentação oficial
    - [ ] Stack Overflow / outros sites

   Descreva brevemente como e para quê usou cada ferramenta.
    
Utilizei o ChatGPT como apoio para relembrar a estrutura do Result Pattern, pois não lembrava todos os detalhes da implementação dele. A intenção foi aplicar esse padrão para evitar acoplamento da camada de Service com códigos HTTP, mantendo a responsabilidade da definição do status code na Controller.

5. (Responda apenas se usou IA) Existe algum trecho de código gerado por IA que você não entendeu completamente mas manteve no projeto? Qual? Por quê?

Não. Compreendo todo o código implementado.