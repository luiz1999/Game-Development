# Game-Development

# 🎮 Jogo de Plataforma 2D — UniFECAF

> Projeto acadêmico desenvolvido para a disciplina de **Game Development** da UniFECAF.  
> Engine: **Unity** · Linguagem: **C#**

---

## 📋 Sobre o Projeto

Um jogo de plataforma 2D clássico com mecânicas de movimento, coleta de moedas, sistema de pontuação, transição de níveis e câmera dinâmica — tudo construído do zero usando Unity Engine e C#.

O objetivo do projeto é aplicar na prática os conceitos da disciplina: física 2D, máquina de estados para animações, gerenciamento de cena e persistência de dados entre fases.

---

## 🎯 Mecânicas Implementadas

| Mecânica | Descrição |
|---|---|
| **Movimento** | Deslocamento horizontal responsivo via `Input.GetAxis` |
| **Pulo** | Impulso com `AddForce`, com detecção de chão via `OnCollisionEnter2D` |
| **Animações** | Máquina de estados (idle / run / jump) com `Animator` e espelhamento de sprite |
| **Coleta de moedas** | Trigger 2D que destrói a moeda e incrementa a pontuação |
| **Zona de morte** | Reinicia a fase e zera a pontuação ao cair fora das plataformas |
| **Transição de nível** | Flag ao final de cada fase carrega a próxima cena com delay configurável |
| **HUD** | Pontuação exibida em tempo real com `TextMeshPro` |
| **Câmera dinâmica** | Segue o jogador horizontalmente, sem recuar quando ele volta |
| **Áudio** | Efeitos de pulo e coleta via `AudioSource`, verificados contra null |

---

## 🗂️ Arquitetura dos Scripts

```
Assets/Scripts/
├── Player.cs         # Controle do personagem (movimento, pulo, animações, áudio)
├── GameManager.cs    # Estado global: pontuação, persistência entre cenas (DontDestroyOnLoad)
├── Coin.cs           # Coleta de moedas via Trigger 2D
├── DeathArea.cs      # Reinício de cena ao contato com zona de morte
├── Flag.cs           # Transição para o próximo nível com delay e validação
└── PlayerCamera.cs   # Câmera que segue o jogador sem retroceder
```

Cada script tem **responsabilidade única**, seguindo o princípio de separação de responsabilidades.

---

## ⚙️ Detalhes Técnicos

### Player.cs
- Movimento via `rb.linearVelocity` preservando o eixo Y (gravidade intacta)
- Pulo só permitido quando `isOnFloor == true`, zerado imediatamente após o salto para impedir pulo duplo
- Espelhamento de sprite via `sprite.flipX` — sem necessidade de sprites separados por direção
- Detecção de chão pela tag `"Ground"` em `OnCollisionEnter2D`
- Método público `PlayCoinSound()` para que `Coin.cs` dispare o som de coleta de forma centralizada

### GameManager.cs
- `score` declarado como `static` — acessível por qualquer script sem referência ao objeto
- `DontDestroyOnLoad` mantém a pontuação ao trocar de cena
- HUD atualizado via `TextMeshProUGUI` a cada frame

### Coin.cs
- Usa `OnTriggerEnter2D` (sem resposta física) — ideal para coletáveis
- `Destroy(gameObject)` ocorre antes do incremento para evitar dupla contagem

### DeathArea.cs
- `SceneManager.GetActiveScene().name` para reinício dinâmico — reutilizável em qualquer fase sem configuração

### Flag.cs
- Campo `nextLevel` validado com `string.IsNullOrEmpty` antes de carregar a cena
- Transição agendada via `Invoke(nameof(LoadScene), loadDelay)` — delay configurável no Inspector
- Atributo `[Header]` para organização visual no Inspector

### PlayerCamera.cs
- A câmera só avança quando `player.x >= camera.x`, impedindo que recue com o jogador

---

## 🗺️ Design de Níveis

O projeto prevê **3 a 5 fases** com dificuldade progressiva:

- **Fase 1** — Tutorial implícito: plataformas amplas, poucos obstáculos, moedas acessíveis
- **Fase 2** — Gaps maiores entre plataformas e obstáculos estáticos
- **Fase 3+** — Zonas de morte mais frequentes e coletáveis que exigem timing preciso de pulo

A pontuação acumulada persiste entre todas as fases via `GameManager`.

---

## 🛠️ Como Abrir o Projeto

**Pré-requisitos:**
- Unity **2022.3 LTS** ou superior (recomendado)
- Módulo **2D** instalado via Unity Hub

**Passos:**
1. Clone o repositório:
   ```bash
   git clone https://github.com/luiz1999/Game-Development.git
   ```
2. Abra o **Unity Hub** → *Add project from disk* → selecione a pasta clonada
3. Aguarde a importação dos assets
4. Abra a cena da **Fase 1** em `Assets/Scenes/` e pressione **Play**

> ⚠️ Certifique-se de que todas as cenas estão registradas em **File → Build Settings → Scenes in Build** para que as transições funcionem corretamente.

---

## 📦 Stack

- **Engine:** Unity (2D)
- **Linguagem:** C#
- **UI:** TextMeshPro
- **Física:** Rigidbody2D, Collider2D, Trigger2D
- **Animações:** Animator Controller (máquina de estados)
- **Áudio:** AudioSource (one-shot)
- **Cenas:** SceneManager + DontDestroyOnLoad

---

## 👤 Autor

**Luiz Filipe Santiago Pereira**  
Disciplina: Game Development — UniFECAF · 2026