| Description                                | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       463.9 ns |     7.44 ns |     6.21 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,305.1 ns |     8.38 ns |     6.54 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,074.3 ns |    38.47 ns |    37.78 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       415.1 ns |     1.80 ns |     1.50 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,254.4 ns |    13.20 ns |    14.12 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     1,987.9 ns |    21.51 ns |    19.07 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,750.2 ns |     4.21 ns |     3.73 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     9,707.8 ns |    23.38 ns |    19.52 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,474.1 ns |    43.64 ns |    38.69 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,696.1 ns |     6.66 ns |     5.91 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,198.3 ns |    26.54 ns |    24.82 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,423.5 ns |    26.85 ns |    20.96 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,095.0 ns |    45.78 ns |    40.58 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    64,198.9 ns |   439.88 ns |   367.32 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    77,031.4 ns |   195.02 ns |   162.85 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    20,981.6 ns |    43.11 ns |    40.32 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    63,679.9 ns |   202.99 ns |   169.51 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    76,446.9 ns |   145.93 ns |   121.85 ns |    2848 B |
|                                            |              |                |             |             |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   334,618.3 ns |   302.22 ns |   267.91 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,210,420.3 ns | 3,128.95 ns | 2,612.82 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,219,205.7 ns | 6,322.52 ns | 5,604.75 ns |    2808 B |
|                                            |              |                |             |             |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   334,240.8 ns |   628.48 ns |   557.13 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,014,675.2 ns | 2,672.90 ns | 2,369.45 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,219,478.3 ns | 2,980.67 ns | 3,548.28 ns |    2848 B |