global main
extern printf

section .data
  fmt db '%d', 10, 0
  arr dd 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 11, 11, 11, 12
  len equ($ - arr) / 4

; Количество четных чисел в массиве
section .text
  main:
    xor eax, eax
    mov ecx, 0

    .for:
      mov edx, [arr + 4 * ecx]
      inc ecx
      test edx, 1
        jz .even
        jnz .compare
      
      .even:
        inc eax

      .compare:
        cmp ecx, len
          jl .for
          je .show

    .show:
      push eax
      push fmt
      call printf

    mov eax, 1
    xor ebx, ebx
    int 0x80