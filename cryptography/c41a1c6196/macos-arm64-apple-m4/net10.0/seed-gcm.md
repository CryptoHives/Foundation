| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.264 μs | 0.0037 μs | 0.0035 μs |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.748 μs | 0.0107 μs | 0.0095 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.877 μs | 0.0055 μs | 0.0046 μs |     856 B |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.213 μs | 0.0056 μs | 0.0053 μs |         - |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.694 μs | 0.0034 μs | 0.0032 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.811 μs | 0.0060 μs | 0.0056 μs |     840 B |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.803 μs | 0.0550 μs | 0.0514 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 1KB          |    11.180 μs | 0.0381 μs | 0.0357 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    11.995 μs | 0.0210 μs | 0.0197 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.748 μs | 0.0399 μs | 0.0373 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 1KB          |    11.112 μs | 0.0368 μs | 0.0344 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    11.775 μs | 0.0338 μs | 0.0299 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    69.096 μs | 0.3008 μs | 0.2814 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 8KB          |    85.081 μs | 0.2735 μs | 0.2425 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    93.777 μs | 0.1770 μs | 0.1478 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    68.994 μs | 0.2003 μs | 0.1874 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 8KB          |    85.176 μs | 0.3038 μs | 0.2842 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    93.277 μs | 0.4425 μs | 0.4139 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,102.948 μs | 7.3394 μs | 6.8653 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,352.463 μs | 5.2093 μs | 4.8728 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,495.303 μs | 5.6457 μs | 5.0047 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,102.840 μs | 4.2442 μs | 3.9700 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,355.017 μs | 5.7628 μs | 5.3905 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,482.504 μs | 5.4203 μs | 5.0702 μs |         - |