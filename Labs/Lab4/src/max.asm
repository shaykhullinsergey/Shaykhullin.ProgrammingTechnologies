global main
extern printf

section .data
  fmt dw '%d', 10, 0
  arr dd 1, 3, 5, 4, 2
  len equ($ - arr) / 4

section .text
  main:
    xor eax, eax
    mov ecx, len
    mov esi, arr

    .for:
      mov edx, [esi]
      add esi, 4
      cmp eax, edx
        jl .max
        jg .compare

    .max:
      mov eax, edx

    .compare:
      dec ecx
      cmp ecx, 0
        je .show
        jne .for

    .show:
      push eax
      push fmt
      call printf

    mov eax, 1
    xor ebx, ebx
    int 0x80