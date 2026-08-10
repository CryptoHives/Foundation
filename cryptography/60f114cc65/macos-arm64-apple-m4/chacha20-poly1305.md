| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20-Poly1305 (Neon)         | 128B         |     416.0 ns |     0.14 ns |     0.13 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     696.4 ns |     1.64 ns |     1.54 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     821.4 ns |     0.29 ns |     0.27 ns |      48 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128B         |   1,280.1 ns |     3.12 ns |     2.76 ns |         - |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128B         |   2,297.3 ns |    10.67 ns |     9.98 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 128B         |     352.7 ns |     1.77 ns |     1.65 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128B         |     497.2 ns |     0.67 ns |     0.63 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128B         |     791.2 ns |     0.12 ns |     0.11 ns |      48 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128B         |   1,323.5 ns |     9.53 ns |     8.91 ns |         - |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128B         |   1,990.8 ns |    19.58 ns |    18.32 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 1KB          |   1,996.2 ns |     5.35 ns |     5.01 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   2,401.0 ns |     0.84 ns |     0.71 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   3,216.6 ns |    17.88 ns |    16.73 ns |         - |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   3,671.4 ns |     0.63 ns |     0.56 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   6,831.6 ns |    19.38 ns |    17.18 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 1KB          |   1,938.1 ns |     1.04 ns |     0.93 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 1KB          |   2,208.0 ns |     1.21 ns |     1.13 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (OS)           | 1KB          |   2,910.0 ns |    20.64 ns |    19.31 ns |         - |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 1KB          |   3,633.8 ns |     1.38 ns |     1.29 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 1KB          |   6,787.1 ns |    21.76 ns |    20.35 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  10,737.4 ns |    34.75 ns |    32.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 8KB          |  14,444.3 ns |     9.44 ns |     7.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  15,871.9 ns |    11.32 ns |    10.03 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  26,323.7 ns |    15.44 ns |    14.44 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  48,854.8 ns |   186.70 ns |   174.64 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 8KB          |  10,242.1 ns |    46.22 ns |    43.23 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 8KB          |  14,477.4 ns |     9.32 ns |     8.71 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 8KB          |  15,750.5 ns |     7.63 ns |     7.14 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 8KB          |  26,247.1 ns |     5.16 ns |     4.31 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 8KB          |  48,757.8 ns |   151.90 ns |   142.08 ns |         - |
|                                            |              |              |             |             |           |
| Decrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 147,864.7 ns |   574.62 ns |   537.50 ns |         - |
| Decrypt · ChaCha20-Poly1305 (Neon)         | 128KB        | 228,853.4 ns |   250.03 ns |   233.88 ns |         - |
| Decrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 247,550.5 ns |   203.68 ns |   170.08 ns |     416 B |
| Decrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 414,374.8 ns |   216.42 ns |   202.44 ns |      72 B |
| Decrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 773,312.9 ns | 3,018.75 ns | 2,823.74 ns |         - |
|                                            |              |              |             |             |           |
| Encrypt · ChaCha20-Poly1305 (OS)           | 128KB        | 138,491.5 ns |   479.11 ns |   448.16 ns |         - |
| Encrypt · ChaCha20-Poly1305 (Neon)         | 128KB        | 228,968.4 ns |    75.74 ns |    70.85 ns |         - |
| Encrypt · ChaCha20-Poly1305 (BouncyCastle) | 128KB        | 249,552.4 ns |   239.94 ns |   224.44 ns |     336 B |
| Encrypt · ChaCha20-Poly1305 (NaCl.Core)    | 128KB        | 414,763.9 ns |   186.84 ns |   165.63 ns |      72 B |
| Encrypt · ChaCha20-Poly1305 (Managed)      | 128KB        | 774,383.7 ns | 3,379.09 ns | 3,160.80 ns |         - |