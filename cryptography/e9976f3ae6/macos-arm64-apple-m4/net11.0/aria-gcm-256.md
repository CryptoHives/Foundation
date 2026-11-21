| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.197 μs |  0.0014 μs |  0.0014 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.655 μs |  0.0028 μs |  0.0027 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     2.890 μs |  0.0146 μs |  0.0137 μs |    2176 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128B         |     1.162 μs |  0.0013 μs |  0.0012 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128B         |     1.665 μs |  0.0095 μs |  0.0089 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128B         |     2.812 μs |  0.0100 μs |  0.0078 μs |    2160 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.320 μs |  0.0116 μs |  0.0109 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.390 μs |  0.0123 μs |  0.0115 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    16.411 μs |  0.0704 μs |  0.0624 μs |    4416 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 1KB          |     8.288 μs |  0.0105 μs |  0.0099 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 1KB          |    11.717 μs |  0.1433 μs |  0.1341 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 1KB          |    16.493 μs |  0.0886 μs |  0.0829 μs |    4400 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    65.306 μs |  0.0958 μs |  0.0896 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    92.923 μs |  0.3092 μs |  0.2893 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   124.409 μs |  0.4030 μs |  0.3769 μs |   22336 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 8KB          |    65.247 μs |  0.0594 μs |  0.0555 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 8KB          |    92.501 μs |  0.7141 μs |  0.6680 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 8KB          |   125.836 μs |  0.7307 μs |  0.6835 μs |   22320 B |
|                                               |              |              |            |            |           |
| Decrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,042.406 μs |  1.4339 μs |  1.3413 μs |         - |
| Decrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,484.848 μs |  5.4056 μs |  5.0564 μs |         - |
| Decrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 1,975.967 μs | 10.4480 μs |  9.7731 μs |  329536 B |
|                                               |              |              |            |            |           |
| Encrypt · ARIA-256-GCM (CryptoHives-ArmPmull) | 128KB        | 1,041.816 μs |  1.6272 μs |  1.5221 μs |         - |
| Encrypt · ARIA-256-GCM (CryptoHives-Scalar)   | 128KB        | 1,479.650 μs |  6.9792 μs |  6.5284 μs |         - |
| Encrypt · ARIA-256-GCM (BouncyCastle)         | 128KB        | 2,002.172 μs | 11.5699 μs | 10.8225 μs |  329520 B |