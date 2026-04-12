| Description                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (Managed)      | 128B         |     1.197 μs | 0.0028 μs | 0.0024 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128B         |     1.297 μs | 0.0060 μs | 0.0050 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 128B         |     1.206 μs | 0.0034 μs | 0.0030 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128B         |     1.294 μs | 0.0049 μs | 0.0046 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 1KB          |     8.571 μs | 0.0171 μs | 0.0160 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 1KB          |     8.791 μs | 0.0294 μs | 0.0275 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 1KB          |     8.644 μs | 0.0170 μs | 0.0151 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 1KB          |     8.837 μs | 0.0318 μs | 0.0297 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 8KB          |    67.551 μs | 0.2498 μs | 0.2214 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 8KB          |    76.017 μs | 0.1365 μs | 0.1277 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 8KB          |    68.199 μs | 0.2854 μs | 0.2383 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 8KB          |    69.151 μs | 0.2095 μs | 0.1960 μs |     152 B |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 128KB        | 1,078.671 μs | 1.9491 μs | 1.8232 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,096.086 μs | 3.2371 μs | 2.8696 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (Managed)      | 128KB        | 1,089.535 μs | 1.9477 μs | 1.8219 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,102.210 μs | 2.6167 μs | 2.3197 μs |     152 B |