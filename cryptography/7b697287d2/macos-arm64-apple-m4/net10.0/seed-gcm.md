| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.234 μs | 0.0057 μs | 0.0053 μs |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.711 μs | 0.0037 μs | 0.0035 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.839 μs | 0.0039 μs | 0.0037 μs |     856 B |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.187 μs | 0.0021 μs | 0.0020 μs |         - |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.669 μs | 0.0092 μs | 0.0077 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.778 μs | 0.0035 μs | 0.0032 μs |     840 B |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.599 μs | 0.0021 μs | 0.0020 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 1KB          |    10.937 μs | 0.0323 μs | 0.0302 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    11.719 μs | 0.0164 μs | 0.0154 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.566 μs | 0.0025 μs | 0.0022 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 1KB          |    10.910 μs | 0.0429 μs | 0.0401 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    11.692 μs | 0.0475 μs | 0.0396 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    67.651 μs | 0.0162 μs | 0.0152 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 8KB          |    83.344 μs | 0.3765 μs | 0.3521 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    91.824 μs | 0.3271 μs | 0.3060 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    67.672 μs | 0.0292 μs | 0.0273 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 8KB          |    83.631 μs | 0.2881 μs | 0.2554 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    91.763 μs | 0.2658 μs | 0.2486 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,080.787 μs | 0.5177 μs | 0.4842 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,328.260 μs | 7.6664 μs | 7.1711 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,463.835 μs | 4.6899 μs | 4.3870 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,080.654 μs | 0.6772 μs | 0.6335 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,334.617 μs | 6.6225 μs | 6.1947 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,461.741 μs | 3.4825 μs | 3.0871 μs |         - |