global main
extern printf

section .data
  fmt dw '%d', 10, 0
  arr dd 1, 2, 3, 4, 5, 6
  len equ ($ - arr) / 4

section .text
  main:
    mov esi, arr
    xor eax, eax
    mov ecx, len

  .for:
    add eax, [esi]
    add esi, 4
    loop .for

    push eax
    push fmt
    call printf

    mov eax, 1
    xor ebx, ebx
    int 0x80