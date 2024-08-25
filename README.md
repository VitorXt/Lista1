Implementação de Inteligência Artificial para Jogos Clássicos

Este repositório contém exemplos de como implementar uma "inteligência de máquina" em diferentes jogos clássicos, utilizando técnicas de análise de padrões e o algoritmo Minimax.

# 1. Jogo do Par ou Ímpar
## Estratégia de Máquina

### •	Aleatoriedade Inicial: A máquina pode começar escolhendo números aleatórios.
### •	Análise de Padrões: Com o tempo, a máquina pode detectar padrões nas escolhas do adversário e adaptar sua estratégia.
### •	Probabilidade e Previsão: A máquina pode atribuir probabilidades às escolhas do jogador com base em jogos anteriores, aumentando suas chances de vencer.

# 2. Jogo da Pedra, Papel e Tesoura
   
## Estratégia de Máquina
### •	Aleatoriedade: A máquina pode escolher entre pedra, papel e tesoura de forma aleatória.
### •	Análise de Padrões: A máquina pode identificar padrões nas escolhas do adversário e usá-los para prever a próxima jogada.
### •	Machine Learning: Uma abordagem mais avançada pode envolver o uso de aprendizado de máquina para melhorar a precisão das previsões com base no histórico de jogadas.

# 3. Jogo Connect 4 (Lig 4)
   
## Análise e Jogada utilizando o Algoritmo Minimax
### Estrutura da Árvore de Decisão

### •	A máquina constrói uma árvore de decisões onde cada nó representa um estado possível do tabuleiro.
### •	Cada movimento possível é simulado, expandindo a árvore até alcançar um estado terminal (vitória, derrota ou empate).

## Função de Avaliação

### •	A função de avaliação atribui valores a cada estado do tabuleiro:
### o	Vitória da máquina: pontuação máxima.
### o	Derrota da máquina: pontuação mínima.
### o	Movimentos intermediários: pontuações que refletem oportunidades futuras ou bloqueios ao adversário.

## Exploração e Seleção do Melhor Movimento

### •	O algoritmo Minimax explora a árvore de forma recursiva, alternando entre maximizar a pontuação para a máquina e minimizar a pontuação do adversário.
### •	A máquina escolhe o movimento que leva ao melhor resultado possível, considerando as jogadas do adversário.

## Podas Alfa-Beta

### •	A poda alfa-beta é uma otimização do algoritmo Minimax que reduz o número de nós explorados, tornando o processo mais eficiente ao eliminar ramos irrelevantes da árvore de decisão.

## Funcionamento Geral da Lógica da Máquina

### 1.	Criação da Árvore de Decisão: A máquina cria uma árvore de possibilidades a partir da posição atual no tabuleiro.
### 2.	Simulação das Jogadas: A máquina simula todas as jogadas possíveis, até alcançar uma condição de fim de jogo ou um certo número de passos à frente.
### 3.	Avaliação dos Estados Finais: Cada estado final é avaliado, atribuindo valores que refletem a qualidade da posição.
### 4.	Escolha da Melhor Jogada: A máquina seleciona a jogada que maximiza suas chances de vitória, minimizando as chances de derrota.

