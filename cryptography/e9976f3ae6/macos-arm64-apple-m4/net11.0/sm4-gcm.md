| Description                              | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       881.2 ns |     2.85 ns |     2.66 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,397.6 ns |     9.63 ns |     9.01 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,772.0 ns |     3.86 ns |     3.61 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128B         |       836.2 ns |     2.09 ns |     1.95 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128B         |     1,363.8 ns |     9.88 ns |     9.24 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128B         |     1,698.6 ns |     6.25 ns |     5.85 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     6,022.3 ns |    24.16 ns |    21.42 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     9,655.2 ns |    94.16 ns |    88.08 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 1KB          |     9,983.5 ns |    49.87 ns |    46.65 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 1KB          |     5,977.8 ns |    18.80 ns |    17.58 ns |         - |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 1KB          |     9,535.7 ns |   105.36 ns |    98.56 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 1KB          |     9,815.1 ns |    36.86 ns |    34.48 ns |     728 B |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    47,253.1 ns |   165.25 ns |   146.49 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    74,624.7 ns |   883.48 ns |   826.41 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 8KB          |    75,383.3 ns |   400.85 ns |   374.95 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 8KB          |    47,084.6 ns |   150.85 ns |   133.72 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 8KB          |    74,589.0 ns |   420.03 ns |   392.90 ns |     728 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 8KB          |    74,803.6 ns |   567.26 ns |   530.62 ns |         - |
|                                          |              |                |             |             |           |
| Decrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   755,601.6 ns | 2,596.23 ns | 2,301.49 ns |         - |
| Decrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,178,077.0 ns | 8,644.64 ns | 8,086.20 ns |         - |
| Decrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,198,526.1 ns | 7,210.57 ns | 6,744.77 ns |     744 B |
|                                          |              |                |             |             |           |
| Encrypt · SM4-GCM (CryptoHives-ArmPmull) | 128KB        |   752,738.0 ns | 2,487.39 ns | 2,326.71 ns |         - |
| Encrypt · SM4-GCM (BouncyCastle)         | 128KB        | 1,185,844.2 ns | 6,528.30 ns | 6,106.57 ns |     728 B |
| Encrypt · SM4-GCM (CryptoHives-Scalar)   | 128KB        | 1,198,433.2 ns | 7,494.94 ns | 7,010.77 ns |         - |