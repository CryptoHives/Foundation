| Description                                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.160 μs | 0.0039 μs | 0.0037 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.548 μs | 0.0023 μs | 0.0021 μs |    1352 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.720 μs | 0.0042 μs | 0.0039 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.148 μs | 0.0057 μs | 0.0053 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128B         |     1.481 μs | 0.0037 μs | 0.0035 μs |    1336 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128B         |     1.671 μs | 0.0063 μs | 0.0059 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.245 μs | 0.0564 μs | 0.0527 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     9.156 μs | 0.0415 μs | 0.0388 μs |    3592 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.867 μs | 0.0272 μs | 0.0254 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.348 μs | 0.0387 μs | 0.0362 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 1KB          |     8.634 μs | 0.0364 μs | 0.0340 μs |    3576 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.609 μs | 0.0372 μs | 0.0348 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    64.318 μs | 0.3542 μs | 0.3313 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    68.033 μs | 0.2367 μs | 0.2214 μs |   21512 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    92.858 μs | 0.2053 μs | 0.1920 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 8KB          |    64.862 μs | 0.4747 μs | 0.4440 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 8KB          |    66.004 μs | 0.2005 μs | 0.1777 μs |   21496 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 8KB          |    92.479 μs | 0.2873 μs | 0.2547 μs |         - |
|                                                   |              |              |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,037.643 μs | 4.6401 μs | 4.3404 μs |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,061.414 μs | 2.4334 μs | 2.2762 μs |  328712 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,477.294 μs | 3.0966 μs | 2.8965 μs |         - |
|                                                   |              |              |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,046.194 μs | 6.4745 μs | 6.0563 μs |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)         | 128KB        | 1,047.388 μs | 3.0484 μs | 2.7023 μs |  328696 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,454.238 μs | 3.7978 μs | 3.5525 μs |         - |