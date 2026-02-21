| Description                                | TestDataSize | Mean         | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |-------------:|-------------:|-------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |     352.8 ns |      4.94 ns |      4.85 ns |         - |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     485.3 ns |      1.95 ns |      1.73 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     548.4 ns |      7.00 ns |      6.55 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     596.6 ns |      7.46 ns |      6.97 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     740.8 ns |      9.16 ns |      8.12 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     885.5 ns |     13.52 ns |     12.64 ns |         - |
|                                            |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |     360.0 ns |      5.47 ns |      5.11 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     448.0 ns |      8.38 ns |     17.85 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128B         |     450.3 ns |      8.21 ns |      7.68 ns |         - |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128B         |     508.7 ns |      8.97 ns |      8.39 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     555.2 ns |      8.30 ns |      7.76 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |     833.6 ns |      8.83 ns |      7.83 ns |         - |
|                                            |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,346.2 ns |     11.57 ns |     10.82 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,770.6 ns |      8.03 ns |      7.12 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,798.5 ns |     15.05 ns |     13.34 ns |         - |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,814.4 ns |     14.79 ns |     11.54 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,646.6 ns |     50.31 ns |     47.06 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,465.8 ns |     58.35 ns |     54.59 ns |         - |
|                                            |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 1KB          |   1,312.5 ns |     16.32 ns |     14.47 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   1,453.1 ns |     20.00 ns |     18.71 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 1KB          |   1,756.8 ns |      5.83 ns |      4.87 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   1,793.7 ns |     12.67 ns |     10.58 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   2,604.7 ns |     32.57 ns |     30.47 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   4,389.6 ns |     64.63 ns |     60.45 ns |         - |
|                                            |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,195.8 ns |     83.09 ns |     77.72 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,853.5 ns |    157.14 ns |    146.99 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,891.3 ns |     76.51 ns |     67.83 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,293.3 ns |    120.74 ns |    107.04 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,802.4 ns |    272.30 ns |    254.71 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  33,123.0 ns |    434.50 ns |    406.43 ns |         - |
|                                            |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 8KB          |   8,178.9 ns |    113.12 ns |    105.81 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |   9,567.3 ns |     97.79 ns |     91.47 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 8KB          |  11,882.8 ns |    144.00 ns |    134.70 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  13,289.4 ns |     61.10 ns |     47.70 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  18,708.7 ns |    189.84 ns |    168.28 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  32,953.2 ns |    434.68 ns |    406.60 ns |         - |
|                                            |              |              |              |              |           |
| Decrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 125,241.6 ns |  1,188.30 ns |  1,111.54 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 150,961.3 ns |  1,960.24 ns |  1,737.70 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 184,976.2 ns |  1,505.09 ns |  1,407.86 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 210,443.2 ns |  1,211.48 ns |  1,133.22 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 295,268.2 ns |  3,265.79 ns |  3,054.83 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 520,611.7 ns |  6,625.74 ns |  6,197.72 ns |         - |
|                                            |              |              |              |              |           |
| Encrypt · ChaCha20-Poly1305 (AVX2)         | 128KB        | 125,606.7 ns |  1,715.78 ns |  1,604.94 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 152,210.0 ns |  2,462.13 ns |  2,303.07 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (SSSE3)        | 128KB        | 184,321.2 ns |  1,193.30 ns |  1,116.21 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 214,386.1 ns |  3,521.93 ns |  3,294.41 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 297,551.9 ns |  3,506.33 ns |  3,279.83 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 528,371.1 ns | 10,080.47 ns | 11,204.42 ns |         - |