| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       463.1 ns |      3.53 ns |      3.13 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,304.8 ns |     18.09 ns |     16.92 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,046.2 ns |     22.57 ns |     20.01 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       418.4 ns |      2.05 ns |      1.81 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,263.4 ns |     15.34 ns |     14.35 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,995.0 ns |     25.31 ns |     23.67 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,781.6 ns |     23.89 ns |     22.34 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,329.0 ns |    136.47 ns |    127.66 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,388.5 ns |     91.36 ns |     85.46 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,734.4 ns |     23.59 ns |     22.06 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,249.2 ns |     81.33 ns |     76.07 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,483.7 ns |    113.46 ns |    100.58 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,148.0 ns |     29.58 ns |     24.70 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    63,720.6 ns |    671.30 ns |    595.09 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    76,427.4 ns |    441.12 ns |    368.36 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,089.4 ns |     74.09 ns |     57.84 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    64,239.3 ns |  1,237.78 ns |  1,157.82 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    77,245.2 ns |    772.69 ns |    722.77 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   336,855.8 ns |  1,431.03 ns |  1,338.58 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,016,565.9 ns |  7,107.09 ns |  6,300.25 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,219,243.1 ns |  8,321.72 ns |  6,949.01 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   337,699.4 ns |  2,717.43 ns |  2,408.93 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,032,830.0 ns | 13,444.74 ns | 12,576.22 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,231,505.1 ns |  8,918.75 ns |  7,906.24 ns |    2848 B |