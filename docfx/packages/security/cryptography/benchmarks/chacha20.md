| Description                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (SSSE3)        | 128B         |     129.1 ns |     1.16 ns |     0.97 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     354.9 ns |     5.87 ns |     5.21 ns |     552 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     464.2 ns |     7.69 ns |     7.19 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (SSSE3)        | 128B         |     130.5 ns |     2.57 ns |     2.76 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     349.4 ns |     6.05 ns |     5.05 ns |     552 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     456.4 ns |     2.18 ns |     1.82 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (SSSE3)        | 1KB          |   1,002.7 ns |     5.44 ns |     4.82 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   2,008.0 ns |    39.56 ns |    40.62 ns |    2344 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   3,587.2 ns |    32.79 ns |    27.38 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (SSSE3)        | 1KB          |   1,007.3 ns |    15.87 ns |    14.07 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,998.5 ns |    29.54 ns |    27.63 ns |    2344 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   3,603.2 ns |    45.80 ns |    40.60 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (SSSE3)        | 8KB          |   8,076.0 ns |   141.72 ns |   132.56 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  15,263.2 ns |   298.87 ns |   418.97 ns |   16680 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  28,620.4 ns |   408.29 ns |   381.92 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (SSSE3)        | 8KB          |   8,185.5 ns |   158.22 ns |   169.29 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  15,134.7 ns |   287.57 ns |   268.99 ns |   16680 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  28,661.7 ns |   378.60 ns |   316.15 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (SSSE3)        | 128KB        | 129,746.9 ns | 2,391.74 ns | 3,109.94 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 295,960.9 ns | 3,987.75 ns | 3,730.15 ns |  262468 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 460,901.9 ns | 7,491.78 ns | 7,007.82 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (SSSE3)        | 128KB        | 128,516.6 ns | 1,823.13 ns | 1,522.40 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 293,105.0 ns | 3,598.72 ns | 3,190.17 ns |  262468 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 457,404.9 ns | 6,873.93 ns | 6,429.87 ns |         - |