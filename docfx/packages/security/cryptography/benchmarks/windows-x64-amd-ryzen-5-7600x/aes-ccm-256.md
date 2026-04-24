| Description                                | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       457.8 ns |      1.62 ns |      1.35 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,326.0 ns |     16.03 ns |     15.00 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,085.4 ns |     28.00 ns |     26.19 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128B         |       419.2 ns |      1.67 ns |      1.39 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128B         |     1,272.7 ns |     13.48 ns |     12.61 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128B         |     2,060.1 ns |     34.88 ns |     37.32 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,758.7 ns |      7.40 ns |      6.56 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,425.9 ns |    119.63 ns |    111.90 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,805.5 ns |    210.83 ns |    197.21 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 1KB          |     2,759.6 ns |     50.95 ns |     47.66 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 1KB          |     8,477.6 ns |    158.16 ns |    169.23 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 1KB          |    10,716.7 ns |    209.81 ns |    224.50 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,699.4 ns |    341.95 ns |    319.86 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    65,523.0 ns |    797.05 ns |    745.56 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    78,214.3 ns |  1,043.83 ns |    976.40 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 8KB          |    21,165.0 ns |     72.50 ns |     60.54 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 8KB          |    66,228.0 ns |  1,312.98 ns |  1,563.01 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 8KB          |    78,365.6 ns |    569.20 ns |    532.43 ns |    2848 B |
|                                            |              |                |              |              |           |
| Decrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   337,879.7 ns |    790.20 ns |    700.49 ns |         - |
| Decrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,043,715.0 ns | 13,713.19 ns | 12,827.33 ns |         - |
| Decrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,241,674.1 ns | 11,207.65 ns | 10,483.65 ns |    2808 B |
|                                            |              |                |              |              |           |
| Encrypt · AES-256-CCM (CryptoHives-AES-NI) | 128KB        |   340,670.5 ns |  3,941.35 ns |  3,291.20 ns |         - |
| Encrypt · AES-256-CCM (CryptoHives-Scalar) | 128KB        | 1,041,979.9 ns | 17,594.69 ns | 16,458.09 ns |         - |
| Encrypt · AES-256-CCM (BouncyCastle)       | 128KB        | 1,238,243.7 ns | 13,973.30 ns | 13,070.63 ns |    2848 B |