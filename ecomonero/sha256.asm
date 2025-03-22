; sha256.asm
org 0x8000
SHA256_START:
    ld hl, (BLOCK-BUF)
    ld bc, 32
    ld de, (BLOCK-BUF)
SHA256_LOOP:
    ld a, (hl)
    xor b
    ld (de), a
    inc hl
    inc de
    dec bc
    ld a, b
    or c
    jr nz, SHA256_LOOP
    ret
CALL-SHA256:
    call SHA256_START
    ret
