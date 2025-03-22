\ ecomonero/blk.fs - Wallet, Miner, Nodo
VARIABLE BLOCK-BUF 256 ALLOT
VARIABLE CHAIN-HEAD
VARIABLE PRIV-KEY 32 ALLOT
VARIABLE PUB-KEY 32 ALLOT
VARIABLE NONCE
VARIABLE XMR-MODE
VARIABLE LOG-BUF 128 ALLOT
VARIABLE WALLET-BALANCE
VARIABLE OVERCLOCK
400 CONSTANT SHA256-CODE

: LOG ( c-addr u -- ) LOG-BUF SWAP CMOVE 0 LOG-BUF + C! ;
: SHA256 ( addr len -- hash-addr ) SHA256-CODE LOAD DROP ;
: COMPRESS-BLOCK ( addr -- ) DUP 128 + 128 XOR ;
: DECOMPRESS-BLOCK ( addr -- ) DUP 128 + 128 XOR ;
: GEN-KEY ( -- ) PRIV-KEY 32 42 FILL PUB-KEY 32 42 FILL ;
: SIGN-TX ( tx-addr tx-len -- sig-addr ) SHA256 DROP PUB-KEY ;
: MINE-ECO ( -- flag ) NONCE @ 1+ DUP NONCE ! SHA256 0= ;
: SEND-TO-HW ( addr len -- ) 0 DO DUP C@ EMIT 1+ LOOP DROP ;
: RECV-FROM-HW ( addr len -- ) 0 DO KEY OVER C! 1+ LOOP DROP ;
: MINE-HW ( -- flag ) BLOCK-BUF 256 SEND-TO-HW BLOCK-BUF 256 RECV-FROM-HW 1 ;
: XMR-BRIDGE ( -- ) XMR-MODE @ IF MINE-HW ELSE MINE-ECO THEN DROP ;
: SAVE-BLOCK ( -- ) BLOCK-BUF 256 0 FPUT ;
: LOAD-BLOCK ( index -- ) BLOCK-BUF 256 ROT FGET ;

: WALLET-INIT ( -- ) GEN-KEY 0 WALLET-BALANCE ! ." Wallet inizializzato" CR ;
: WALLET-CHECK ( -- ) ." Saldo: " WALLET-BALANCE @ . CR ;
: WALLET-ADD ( n -- ) WALLET-BALANCE @ + WALLET-BALANCE ! ;

: NODE-INIT ( -- ) 0 CHAIN-HEAD ! ;
: NODE-RUN ( -- ) NODE-INIT BEGIN KEY 27 = UNTIL ;

: POOL-INIT ( -- ) NODE-INIT ;
: POOL-RUN ( -- ) POOL-INIT BEGIN MINE-ECO UNTIL ;

: ECOMONERO-INIT ( -- ) WALLET-INIT NODE-INIT ." EcoMonero pronto!" CR ;
: MINER ( -- ) MINE-ECO IF 10 WALLET-ADD ." Blocco minato!" CR THEN SAVE-BLOCK ;

: NODE NODE-RUN ;
: POOL POOL-RUN ;
: XMR-ON 1 XMR-MODE ! ." Ponte XMR attivo" CR ;
: XMR-OFF 0 XMR-MODE ! ." Ponte XMR disattivo" CR ;
: OVERCLOCK-ON 1 OVERCLOCK ! ." Overclock attivo" CR ;
: OVERCLOCK-OFF 0 OVERCLOCK ! ." Overclock disattivo" CR ;
