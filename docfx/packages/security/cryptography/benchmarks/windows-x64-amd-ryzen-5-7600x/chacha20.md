| Description                       | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      69.35 ns |     0.420 ns |     0.372 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     138.73 ns |     0.492 ns |     0.461 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     278.81 ns |     0.584 ns |     0.518 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     312.38 ns |     2.162 ns |     2.022 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     456.26 ns |     1.726 ns |     1.530 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      68.37 ns |     0.699 ns |     0.584 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     126.08 ns |     1.027 ns |     0.910 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     280.29 ns |     1.233 ns |     1.093 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     311.22 ns |     1.363 ns |     1.275 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     457.15 ns |     2.621 ns |     2.323 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     518.82 ns |     2.400 ns |     2.127 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     997.06 ns |     4.181 ns |     3.911 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,725.47 ns |     3.335 ns |     2.957 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,788.07 ns |     5.069 ns |     4.493 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,559.77 ns |    12.607 ns |    11.792 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     518.93 ns |     2.942 ns |     2.752 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     997.49 ns |     5.939 ns |     4.959 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,639.64 ns |     6.930 ns |     6.482 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,783.17 ns |     7.175 ns |     6.711 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,562.85 ns |    16.331 ns |    14.477 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,124.10 ns |    18.451 ns |    15.407 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   8,019.66 ns |    46.294 ns |    43.303 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,303.88 ns |    18.649 ns |    15.573 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,488.19 ns |    76.669 ns |    71.716 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,386.54 ns |   135.857 ns |   127.081 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,125.16 ns |    20.295 ns |    18.983 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,013.80 ns |    66.035 ns |    58.538 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,396.58 ns |    63.202 ns |    59.119 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,501.58 ns |    69.129 ns |    64.663 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,413.07 ns |   175.062 ns |   163.753 ns |         - |
|                                   |              |               |              |              |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  66,007.44 ns |   312.177 ns |   260.682 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,589.64 ns |   346.265 ns |   306.955 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 178,137.81 ns |   397.383 ns |   371.712 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,907.58 ns |   860.247 ns |   762.587 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 454,508.82 ns | 2,104.854 ns | 1,968.882 ns |         - |
|                                   |              |               |              |              |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,918.18 ns |   368.616 ns |   307.811 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,666.07 ns |   630.683 ns |   492.396 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 184,251.34 ns |   266.467 ns |   222.512 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 215,095.90 ns | 1,001.317 ns |   936.632 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 452,508.50 ns | 1,691.502 ns | 1,582.232 ns |         - |