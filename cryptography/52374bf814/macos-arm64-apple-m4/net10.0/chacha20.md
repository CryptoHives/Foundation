| Description                       | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|---------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · ChaCha20 (Neon)         | 128B         |     170.2 ns |     0.05 ns |     0.05 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128B         |     304.1 ns |     1.49 ns |     1.32 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 128B         |     521.2 ns |     0.19 ns |     0.18 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 128B         |     692.3 ns |     2.27 ns |     2.12 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 128B         |     170.2 ns |     0.07 ns |     0.06 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128B         |     299.9 ns |     4.36 ns |     4.08 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 128B         |     521.1 ns |     0.20 ns |     0.19 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 128B         |     698.0 ns |     2.51 ns |     2.35 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 1KB          |   1,336.0 ns |     0.72 ns |     0.64 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,812.7 ns |    22.35 ns |    19.81 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 1KB          |   2,935.6 ns |     0.94 ns |     0.78 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 1KB          |   5,466.8 ns |    13.05 ns |    11.57 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 1KB          |   1,335.9 ns |     0.90 ns |     0.84 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 1KB          |   1,868.0 ns |    36.32 ns |    37.29 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 1KB          |   2,935.4 ns |     0.89 ns |     0.83 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 1KB          |   5,495.7 ns |    17.69 ns |    16.55 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 8KB          |  10,652.9 ns |     2.54 ns |     2.12 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,452.3 ns |   196.17 ns |   183.50 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 8KB          |  22,244.7 ns |    11.08 ns |    10.37 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 8KB          |  43,589.3 ns |   170.58 ns |   159.56 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 8KB          |  10,655.7 ns |     5.51 ns |     5.15 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 8KB          |  13,947.8 ns |    22.50 ns |    21.05 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 8KB          |  22,251.6 ns |     5.66 ns |     4.72 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 8KB          |  43,758.3 ns |   189.25 ns |   177.03 ns |         - |
|                                   |              |              |             |             |           |
| Decrypt · ChaCha20 (Neon)         | 128KB        | 170,370.4 ns |    30.76 ns |    27.27 ns |         - |
| Decrypt · ChaCha20 (BouncyCastle) | 128KB        | 211,614.5 ns |   273.29 ns |   255.64 ns |      96 B |
| Decrypt · ChaCha20 (NaCl.Core)    | 128KB        | 353,412.1 ns |    32.71 ns |    27.31 ns |      24 B |
| Decrypt · ChaCha20 (Managed)      | 128KB        | 697,996.7 ns | 2,113.03 ns | 1,976.53 ns |         - |
|                                   |              |              |             |             |           |
| Encrypt · ChaCha20 (Neon)         | 128KB        | 170,355.3 ns |    79.47 ns |    66.36 ns |         - |
| Encrypt · ChaCha20 (BouncyCastle) | 128KB        | 212,054.6 ns |   185.30 ns |   173.33 ns |      96 B |
| Encrypt · ChaCha20 (NaCl.Core)    | 128KB        | 353,326.8 ns |   199.21 ns |   186.34 ns |      24 B |
| Encrypt · ChaCha20 (Managed)      | 128KB        | 699,802.4 ns | 3,056.58 ns | 2,859.13 ns |         - |