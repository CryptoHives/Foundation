| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.217 μs | 0.0044 μs | 0.0041 μs |         - |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.761 μs | 0.0061 μs | 0.0051 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.827 μs | 0.0071 μs | 0.0066 μs |     856 B |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128B         |     1.186 μs | 0.0069 μs | 0.0065 μs |         - |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128B         |     1.713 μs | 0.0085 μs | 0.0071 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128B         |     1.747 μs | 0.0050 μs | 0.0047 μs |     840 B |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.596 μs | 0.0620 μs | 0.0580 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 1KB          |    10.848 μs | 0.0342 μs | 0.0320 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    12.128 μs | 0.0801 μs | 0.0749 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 1KB          |     8.509 μs | 0.0544 μs | 0.0509 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 1KB          |    10.616 μs | 0.0518 μs | 0.0484 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 1KB          |    12.173 μs | 0.0659 μs | 0.0616 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    67.414 μs | 0.4545 μs | 0.4252 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 8KB          |    82.707 μs | 0.4623 μs | 0.4324 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    94.221 μs | 0.4457 μs | 0.4169 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 8KB          |    67.289 μs | 0.4208 μs | 0.3936 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 8KB          |    81.437 μs | 0.4053 μs | 0.3792 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 8KB          |    93.878 μs | 0.3840 μs | 0.3404 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,077.862 μs | 5.1672 μs | 4.8334 μs |         - |
| Decrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,320.588 μs | 8.3872 μs | 7.8454 μs |     856 B |
| Decrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,503.400 μs | 5.1822 μs | 4.8475 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · SEED-GCM (CryptoHives-ArmPmull) | 128KB        | 1,075.251 μs | 2.8987 μs | 2.5696 μs |         - |
| Encrypt · SEED-GCM (BouncyCastle)         | 128KB        | 1,302.643 μs | 5.1945 μs | 4.8589 μs |     840 B |
| Encrypt · SEED-GCM (CryptoHives-Scalar)   | 128KB        | 1,507.514 μs | 8.5240 μs | 7.9733 μs |         - |