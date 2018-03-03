global main
extern printf

section .data
  fmt db '%d', 10, 0
  arr1 dd 1, 2, 3, 4, 5
  len equ($ - arr1) / 4
  arr2 dd 1, 2, 3, 4, 5

section .bss
  arr3 resd len * 4

; Поэлементно сложить два массива
section .text
  main:
    xor esi, esi

    .for:
      mov eax, [arr1 + 4 * esi]
      add eax, [arr2 + 4 * esi]
      mov [arr3 + 4 * esi], eax
      
      .show:
        push eax
        push fmt
        call printf
        
      .compare:
        inc esi
        cmp esi, len
          jl .for

    mov eax, 1
    xor ebx, ebx
    int 0x80