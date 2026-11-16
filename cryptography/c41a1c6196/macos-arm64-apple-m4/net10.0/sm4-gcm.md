| Description                              | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       876.6 ns |     3.47 ns |     3.25 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,357.4 ns |     6.51 ns |     5.09 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,814.2 ns |     9.29 ns |     8.69 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       831.5 ns |     4.32 ns |     4.04 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,295.8 ns |     6.36 ns |     5.95 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,754.5 ns |     5.80 ns |     5.43 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     5,983.0 ns |    17.53 ns |    16.39 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     9,216.2 ns |    46.91 ns |    43.88 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 1KB          |    10,217.1 ns |    35.51 ns |    31.48 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     5,959.9 ns |    24.41 ns |    22.84 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     9,139.5 ns |    51.14 ns |    47.84 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 1KB          |    10,204.7 ns |    41.15 ns |    36.48 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    46,946.1 ns |   166.21 ns |   155.47 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    71,844.7 ns |   391.18 ns |   365.91 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 8KB          |    77,103.2 ns |   305.20 ns |   285.49 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    47,016.3 ns |   200.30 ns |   177.57 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    70,803.9 ns |   460.82 ns |   431.05 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 8KB          |    77,204.0 ns |   305.84 ns |   271.12 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   748,442.1 ns | 2,829.04 ns | 2,507.87 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,140,260.4 ns | 6,683.08 ns | 6,251.36 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,226,109.8 ns | 6,080.61 ns | 5,687.80 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   749,982.7 ns | 2,227.73 ns | 1,974.82 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,131,145.1 ns | 7,132.74 ns | 6,671.97 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,226,891.2 ns | 6,288.90 ns | 5,882.64 ns |     728 B |