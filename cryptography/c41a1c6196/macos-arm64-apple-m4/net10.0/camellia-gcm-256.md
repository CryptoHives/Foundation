| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.174 μs | 0.0045 μs | 0.0042 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.629 μs | 0.0040 μs | 0.0038 μs |    1352 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.686 μs | 0.0073 μs | 0.0068 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.138 μs | 0.0047 μs | 0.0044 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.567 μs | 0.0047 μs | 0.0044 μs |    1336 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.647 μs | 0.0052 μs | 0.0046 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.115 μs | 0.0451 μs | 0.0422 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     9.075 μs | 0.0515 μs | 0.0482 μs |    3592 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.605 μs | 0.0303 μs | 0.0283 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.049 μs | 0.0481 μs | 0.0450 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     9.254 μs | 0.0418 μs | 0.0391 μs |    3576 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.632 μs | 0.0300 μs | 0.0281 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    63.476 μs | 0.2418 μs | 0.2261 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    68.757 μs | 0.3169 μs | 0.2964 μs |   21512 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    91.476 μs | 0.4323 μs | 0.4044 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    63.331 μs | 0.2348 μs | 0.2197 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    70.460 μs | 0.2873 μs | 0.2687 μs |   21496 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    91.166 μs | 0.3657 μs | 0.3421 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,021.064 μs | 6.2538 μs | 5.8498 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,096.923 μs | 6.3394 μs | 5.9299 μs |  328712 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,468.194 μs | 6.5245 μs | 6.1030 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,014.613 μs | 5.8324 μs | 5.4557 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,123.997 μs | 5.8008 μs | 5.4261 μs |  328696 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,459.563 μs | 6.3742 μs | 5.9624 μs |         - |