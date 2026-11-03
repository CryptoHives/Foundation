| Description                                       | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|-------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       860.4 ns |     3.93 ns |     3.67 ns |         - |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,318.6 ns |     9.17 ns |     8.57 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,332.6 ns |     6.75 ns |     6.31 ns |    1320 B |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128B         |       821.9 ns |     3.75 ns |     3.51 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128B         |     1,263.6 ns |     5.54 ns |     5.18 ns |    1304 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128B         |     1,282.7 ns |     6.27 ns |     5.86 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     5,934.3 ns |    22.45 ns |    21.00 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     7,286.1 ns |    32.14 ns |    30.06 ns |    3560 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     8,960.8 ns |    47.90 ns |    44.81 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 1KB          |     5,857.9 ns |    28.07 ns |    26.26 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 1KB          |     7,527.2 ns |    38.70 ns |    32.31 ns |    3544 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 1KB          |     8,899.3 ns |    48.16 ns |    45.05 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    46,502.3 ns |   170.18 ns |   159.19 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    54,406.1 ns |   240.29 ns |   224.77 ns |   21480 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    70,281.3 ns |   350.77 ns |   310.95 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 8KB          |    46,353.5 ns |   231.11 ns |   204.87 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 8KB          |    57,933.6 ns |   213.36 ns |   199.58 ns |   21464 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 8KB          |    69,965.0 ns |   469.94 ns |   439.58 ns |         - |
|                                                   |              |                |             |             |           |
| Decrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   741,574.7 ns | 2,371.07 ns | 2,101.89 ns |         - |
| Decrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   869,054.1 ns | 3,447.05 ns | 3,224.37 ns |  328680 B |
| Decrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,120,437.3 ns | 6,278.48 ns | 5,872.89 ns |         - |
|                                                   |              |                |             |             |           |
| Encrypt · Camellia-128-GCM (CryptoHives-ArmPmull) | 128KB        |   740,668.1 ns | 7,140.39 ns | 6,679.12 ns |         - |
| Encrypt · Camellia-128-GCM (BouncyCastle)         | 128KB        |   888,801.3 ns | 2,867.66 ns | 2,682.41 ns |  328664 B |
| Encrypt · Camellia-128-GCM (CryptoHives-Scalar)   | 128KB        | 1,115,475.5 ns | 6,384.60 ns | 5,972.16 ns |         - |