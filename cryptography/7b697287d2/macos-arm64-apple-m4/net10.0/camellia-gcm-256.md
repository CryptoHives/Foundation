| Description                                       | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|-------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.145 μs |  0.0070 μs |  0.0065 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.615 μs |  0.0063 μs |  0.0059 μs |    1352 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.682 μs |  0.0086 μs |  0.0081 μs |         - |
|                                                   |              |              |            |            |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.115 μs |  0.0077 μs |  0.0072 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.544 μs |  0.0063 μs |  0.0056 μs |    1336 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.642 μs |  0.0139 μs |  0.0116 μs |         - |
|                                                   |              |              |            |            |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     7.996 μs |  0.0447 μs |  0.0419 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     8.994 μs |  0.0324 μs |  0.0303 μs |    3592 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.550 μs |  0.0587 μs |  0.0520 μs |         - |
|                                                   |              |              |            |            |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     7.955 μs |  0.0560 μs |  0.0524 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     9.171 μs |  0.0275 μs |  0.0230 μs |    3576 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.497 μs |  0.0784 μs |  0.0734 μs |         - |
|                                                   |              |              |            |            |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    62.673 μs |  0.3601 μs |  0.3192 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    67.649 μs |  0.3274 μs |  0.3062 μs |   21512 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    90.666 μs |  0.5865 μs |  0.5486 μs |         - |
|                                                   |              |              |            |            |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    62.585 μs |  0.4553 μs |  0.4258 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    69.742 μs |  0.3157 μs |  0.2953 μs |   21496 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    90.468 μs |  0.6855 μs |  0.6412 μs |         - |
|                                                   |              |              |            |            |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,019.203 μs |  8.2707 μs |  7.7364 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,089.255 μs |  6.3275 μs |  5.9188 μs |  328712 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,444.703 μs | 11.4504 μs | 10.7107 μs |         - |
|                                                   |              |              |            |            |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,018.775 μs |  9.9304 μs |  9.2889 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,110.950 μs |  5.1461 μs |  4.8137 μs |  328696 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,448.734 μs |  7.0369 μs |  6.5823 μs |         - |