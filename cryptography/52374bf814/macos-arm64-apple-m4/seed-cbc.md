| Description                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (Managed)      | 128B         |     1.316 μs | 0.0142 μs | 0.0126 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128B         |     1.400 μs | 0.0069 μs | 0.0064 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 128B         |     1.428 μs | 0.0050 μs | 0.0044 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 128B         |     1.439 μs | 0.0052 μs | 0.0049 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 1KB          |     9.363 μs | 0.0453 μs | 0.0424 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.601 μs | 0.0523 μs | 0.0489 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.960 μs | 0.0510 μs | 0.0477 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 1KB          |    10.463 μs | 0.0413 μs | 0.0386 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 8KB          |    73.523 μs | 0.2633 μs | 0.2463 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 8KB          |    75.218 μs | 0.3217 μs | 0.3009 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 8KB          |    78.222 μs | 0.4169 μs | 0.3899 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 8KB          |    82.674 μs | 0.3556 μs | 0.3327 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 128KB        | 1,178.190 μs | 5.9217 μs | 5.5392 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,200.086 μs | 5.2922 μs | 4.9504 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,250.964 μs | 5.3121 μs | 4.9690 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 128KB        | 1,324.827 μs | 6.9881 μs | 6.5367 μs |         - |