| Description                       | TestDataSize | Mean          | Error        | StdDev     | Allocated |
|---------------------------------- |------------- |--------------:|-------------:|-----------:|----------:|
| Decrypt · ChaCha20 (AVX2)         | 128B         |      69.59 ns |     0.218 ns |   0.204 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     126.76 ns |     0.348 ns |   0.326 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     278.44 ns |     0.453 ns |   0.401 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     310.75 ns |     1.555 ns |   1.378 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     455.61 ns |     1.011 ns |   0.896 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 128B         |      69.57 ns |     0.255 ns |   0.239 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     127.15 ns |     0.448 ns |   0.397 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     275.74 ns |     0.601 ns |   0.532 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     311.08 ns |     1.471 ns |   1.376 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     453.72 ns |     0.642 ns |   0.536 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 1KB          |     518.41 ns |     2.004 ns |   1.674 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |     996.97 ns |     3.089 ns |   2.889 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,532.46 ns |     2.528 ns |   2.365 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,773.41 ns |     4.306 ns |   3.817 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,533.76 ns |     5.183 ns |   4.328 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 1KB          |     519.55 ns |     0.845 ns |   0.749 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |     997.98 ns |     2.857 ns |   2.533 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   1,516.30 ns |     3.596 ns |   3.364 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,772.53 ns |     4.127 ns |   3.658 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,534.00 ns |    10.199 ns |   9.540 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 8KB          |   4,115.97 ns |    12.326 ns |  11.530 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   7,964.21 ns |    18.820 ns |  14.693 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,234.60 ns |    26.227 ns |  24.533 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,457.44 ns |    43.923 ns |  41.085 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,214.67 ns |    60.660 ns |  56.741 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 8KB          |   4,113.19 ns |    10.491 ns |   9.300 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   7,965.67 ns |    15.427 ns |  14.431 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  11,214.97 ns |    39.443 ns |  32.937 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,440.45 ns |    32.124 ns |  30.049 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,213.69 ns |   118.836 ns | 111.159 ns |         - |
|                                   |              |               |              |            |           |
| Decrypt · ChaCha20 (AVX2)         | 128KB        |  65,754.71 ns |   139.106 ns | 130.120 ns |         - |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 127,509.78 ns |   352.916 ns | 330.118 ns |         - |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 179,738.53 ns |   388.363 ns | 363.275 ns |      24 B |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 213,875.83 ns |   426.368 ns | 398.825 ns |      96 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 449,563.03 ns |   945.690 ns | 884.599 ns |         - |
|                                   |              |               |              |            |           |
| Encrypt · ChaCha20 (AVX2)         | 128KB        |  65,837.11 ns |   320.097 ns | 267.295 ns |         - |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 127,294.49 ns |   277.559 ns | 259.629 ns |         - |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 179,465.77 ns |   358.169 ns | 335.031 ns |      24 B |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 214,007.65 ns |   604.036 ns | 565.015 ns |      96 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 449,849.08 ns | 1,048.545 ns | 929.508 ns |         - |