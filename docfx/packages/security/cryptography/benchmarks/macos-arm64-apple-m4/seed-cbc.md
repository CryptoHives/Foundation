| Description                       | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · SEED-CBC (Managed)      | 128B         |     1.314 μs | 0.0046 μs | 0.0043 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128B         |     1.394 μs | 0.0050 μs | 0.0047 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 128B         |     1.426 μs | 0.0048 μs | 0.0045 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 128B         |     1.440 μs | 0.0045 μs | 0.0042 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 1KB          |     9.355 μs | 0.0349 μs | 0.0327 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.606 μs | 0.0327 μs | 0.0306 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.945 μs | 0.0417 μs | 0.0390 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 1KB          |    10.474 μs | 0.0342 μs | 0.0320 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 8KB          |    73.554 μs | 0.2447 μs | 0.2289 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 8KB          |    75.150 μs | 0.2485 μs | 0.2324 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 8KB          |    78.079 μs | 0.2776 μs | 0.2597 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 8KB          |    82.713 μs | 0.4122 μs | 0.3856 μs |         - |
|                                   |              |              |           |           |           |
| Decrypt · SEED-CBC (Managed)      | 128KB        | 1,176.421 μs | 4.3357 μs | 4.0556 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,199.266 μs | 4.4717 μs | 4.1829 μs |     152 B |
|                                   |              |              |           |           |           |
| Encrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,247.962 μs | 4.9240 μs | 4.6059 μs |     152 B |
| Encrypt · SEED-CBC (Managed)      | 128KB        | 1,323.783 μs | 4.6407 μs | 4.3409 μs |         - |