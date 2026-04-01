| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      74.67 ns |     0.142 ns |     0.126 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     127.79 ns |     0.497 ns |     0.441 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     277.98 ns |     0.637 ns |     0.565 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     307.08 ns |     1.682 ns |     1.573 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     455.01 ns |     0.964 ns |     0.901 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      73.84 ns |     0.283 ns |     0.221 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     127.72 ns |     0.407 ns |     0.381 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     277.93 ns |     0.823 ns |     0.770 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     308.18 ns |     1.069 ns |     1.000 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     453.89 ns |     0.718 ns |     0.671 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     524.12 ns |     2.837 ns |     2.369 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     996.60 ns |     2.730 ns |     2.279 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,501.58 ns |     4.661 ns |     4.360 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,769.47 ns |     5.448 ns |     5.096 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,529.41 ns |    10.726 ns |    10.033 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     525.86 ns |     1.604 ns |     1.422 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     999.89 ns |     6.203 ns |     5.803 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,507.15 ns |     2.222 ns |     1.969 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,773.93 ns |     4.289 ns |     4.012 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,528.09 ns |     5.091 ns |     4.513 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,124.02 ns |    17.872 ns |    16.717 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,982.12 ns |    37.310 ns |    31.156 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,363.04 ns |    13.686 ns |    12.802 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,441.57 ns |    42.868 ns |    40.099 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,207.56 ns |    76.489 ns |    71.548 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,121.93 ns |    12.895 ns |    11.431 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   7,986.06 ns |    32.093 ns |    30.020 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,322.71 ns |    27.803 ns |    26.007 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,436.35 ns |    34.656 ns |    28.939 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,169.65 ns |    64.434 ns |    60.271 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  65,898.91 ns |   214.841 ns |   167.734 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,801.24 ns |   533.152 ns |   445.206 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 180,025.82 ns |   405.332 ns |   379.148 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,098.75 ns |   561.224 ns |   524.969 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 449,581.94 ns | 1,529.613 ns | 1,430.801 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,936.12 ns |   356.337 ns |   315.883 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,836.06 ns |   445.971 ns |   395.342 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 178,200.56 ns |   445.600 ns |   416.815 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 213,946.74 ns |   693.002 ns |   614.328 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 448,639.98 ns | 1,018.874 ns |   903.205 ns |         - |