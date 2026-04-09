| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      74.31 ns |     0.312 ns |     0.261 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     127.65 ns |     0.400 ns |     0.374 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     280.17 ns |     0.697 ns |     0.652 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     311.20 ns |     0.995 ns |     0.931 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     454.80 ns |     0.960 ns |     0.898 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      74.30 ns |     0.282 ns |     0.250 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     128.28 ns |     0.695 ns |     0.616 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     276.53 ns |     0.572 ns |     0.535 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     311.20 ns |     1.115 ns |     1.043 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     454.84 ns |     1.339 ns |     1.253 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     522.94 ns |     2.034 ns |     1.903 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     997.30 ns |     4.771 ns |     4.463 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,728.87 ns |     8.763 ns |     8.197 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,779.52 ns |     3.476 ns |     3.251 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,535.79 ns |     6.177 ns |     5.778 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     523.42 ns |     1.572 ns |     1.470 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     999.48 ns |     2.933 ns |     2.744 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,506.51 ns |     3.928 ns |     3.674 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,775.72 ns |     3.412 ns |     3.191 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,529.71 ns |     8.821 ns |     8.251 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,124.11 ns |    13.382 ns |    11.863 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,986.08 ns |    35.864 ns |    31.792 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,318.26 ns |    33.375 ns |    31.219 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,477.35 ns |    38.886 ns |    36.374 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,154.60 ns |    57.260 ns |    50.760 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,117.25 ns |    16.598 ns |    15.525 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   7,969.47 ns |    26.509 ns |    20.696 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,281.78 ns |    27.703 ns |    25.913 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,472.93 ns |    25.527 ns |    21.316 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,253.72 ns |    45.530 ns |    40.361 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,041.90 ns |   515.727 ns |   430.656 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,517.28 ns |   380.361 ns |   317.618 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 179,810.49 ns |   487.395 ns |   455.909 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,428.57 ns |   561.812 ns |   525.520 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 451,066.71 ns | 1,143.348 ns | 1,069.488 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,762.94 ns |   205.952 ns |   182.571 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,660.30 ns |   433.544 ns |   362.029 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,852.70 ns |   411.188 ns |   364.508 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,339.35 ns |   495.581 ns |   439.320 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 449,409.41 ns | 1,470.623 ns | 1,303.669 ns |         - |