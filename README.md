# EcoMonero
# EcoMonero su CollapseOS: La Crypto del Collasso

![EcoMonero Logo](https://via.placeholder.com/150) <!-- Sostituisci con un logo se ne hai uno -->

Benvenuti in un progetto che non segue le regole della crypto moderna, ma le riscrive per un mondo al confine del collasso. `EcoMonero` non è una moneta per speculatori o HODLer da yacht: è una criptovaluta leggera, resiliente e post-apocalittica, integrata in `CollapseOS`, il sistema operativo per hardware obsoleto. Qui non ci sono GPU da 1000 watt o blockchain da terabyte: solo codice puro, wallet, miner e nodi che girano su macchine che la società ha dimenticato.

## Cos’è EcoMonero?
`EcoMonero` è una suite crypto completa, costruita per sopravvivere dove Bitcoin ed Ethereum fallirebbero:
- **Wallet**: Chiavi private/pubbliche e saldo su un floppy disk.
- **Miner**: Algoritmo eco-friendly che mina senza fondere il pianeta.
- **Nodo**: Sincronizza una blockchain minimale su un 386.
- **Ponte XMR**: Collega a Monero per transazioni reali, senza dipendere dal cloud.
- **Gateway Seriale**: Porta la rete su hardware fisico tramite porte seriali.

Basato su Forth e assemblato in `CollapseOS`, questo progetto è per chi vede oltre il hype e prepara il futuro.

## Perché EcoMonero?
- **Post-Grid Ready**: Funziona senza internet, senza data center, senza corrente stabile.
- **Anti-Mainstream**: Sfida le crypto energivore e centralizzate con un’alternativa cruda e reale.
- **Resilienza**: Progettato per un mondo dove la tecnologia moderna è un ricordo.
- **Overclock**: Spingi il tuo hardware al limite. Sopravvivi o brucia.

## Struttura del progetto
collapseos/
├── blk/
│   ├── 001          # Avvio: 400 LOAD ECOMONERO-INIT
│   ├── blk400       # Filesystem Forth generato (placeholder)
├── ecomonero/
│   ├── blk.fs       # Core: wallet, miner, nodo
│   ├── gateway.c    # Gateway seriale per rete reale
│   ├── sha256.asm   # Hashing ottimizzato
├── tools/           # blkpack, emul (ereditati da CollapseOS)
├── README.md        # Questo file



## Come iniziare
### Prerequisiti
- PC con Windows o Ubuntu.
- Git, Python 3, GCC/Clang, Make.
- (Opzionale) Hardware seriale (es. USB-to-serial).

### Installazione
1. **Fork e clona**:
   - Vai su: `https://github.com/HighKali/collapseos`.
   - Clicca **Fork**.
   - (Facoltativo, via terminale): `git clone https://github.com/HighKali/collapseos.git`.

2. **Aggiungi EcoMonero** (via GitHub web):
   - Vai su: `https://github.com/HighKali/collapseos`.
   - Crea branch: `ecomonero-integration`.
   - Aggiungi i file in `ecomonero/` e modifica `blk/` (vedi [Wiki](#wiki)).

3. **Genera blk400**:
   - Usa `tools/blkpack` (richiede terminale):
     ```
     python tools/blkpack ecomonero/blk.fs > blk/blk400
     ```

### Test
#### Emulazione
- Compila ed esegui:
  cp tools/emul/zasm/zasm kernel.asm os.bin
  tools/emul/runbin os.bin

- Comandi: `ECOMONERO-INIT`, `MINER`, `WALLET-CHECK`.

#### Rete reale
- Compila `gateway.c`:
- Windows: `gcc ecomonero/gateway.c -o gateway.exe` (modifica `SERIAL_PORT` a `COM1`).
- Ubuntu: `gcc ecomonero/gateway.c -o gateway` (modifica a `/dev/ttyUSB0`).
- Esegui: `./gateway` o `gateway.exe`.

## Sfida alla comunità Crypto
- **Minatori**: Mina un blocco su un Pentium del ’95. Posta i risultati su X con `#EcoMonero`.
- **Nodisti**: Sincronizza un nodo senza Wi-Fi. Dimostra che la rete vive.
- **Hackers**: Ottimizza `sha256.asm`. Fai vedere chi comanda.

## Wiki
Vuoi sapere di più? La [Wiki](https://github.com/HighKali/collapseos/wiki/EcoMonero) ti aspetta con il manifesto completo e le provocazioni per la comunità crypto.

## Contribuisci
- Forka, modifica, fai una PR.
- Idee folli? Aprila su **Issues**.
- Test su hardware assurdo? Documentalo nella Wiki.

## Licenza
Ereditata da `CollapseOS`: [GPL-2.0](https://www.gnu.org/licenses/gpl-2.0.html). Usa, modifica, condividi.

## Il futuro è ora
`EcoMonero` non è un sogno da whitepaper: è codice che funziona, pronto a esplodere le convenzioni della crypto. Unisciti al collasso, o guardaci ridefinire la decentralizzazione.

---
**Tagga #EcoMonero su X e scuoti la rete!**
  

