| Description                       | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|---------------------------------- |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| Decrypt · SEED-CBC (Managed)      | 128B         |     1.300 μs |  0.0116 μs |  0.0103 μs |     1.297 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128B         |     1.418 μs |  0.0210 μs |  0.0224 μs |     1.412 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Encrypt · SEED-CBC (Managed)      | 128B         |     1.305 μs |  0.0096 μs |  0.0090 μs |     1.306 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128B         |     1.439 μs |  0.0266 μs |  0.0531 μs |     1.417 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Decrypt · SEED-CBC (Managed)      | 1KB          |     9.291 μs |  0.0595 μs |  0.0556 μs |     9.290 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.578 μs |  0.0946 μs |  0.0885 μs |     9.569 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Encrypt · SEED-CBC (Managed)      | 1KB          |     9.445 μs |  0.0997 μs |  0.0933 μs |     9.456 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 1KB          |     9.621 μs |  0.0833 μs |  0.0780 μs |     9.612 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Decrypt · SEED-CBC (Managed)      | 8KB          |    73.485 μs |  0.6943 μs |  0.6495 μs |    73.566 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 8KB          |    74.524 μs |  0.9388 μs |  0.7839 μs |    74.080 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Encrypt · SEED-CBC (Managed)      | 8KB          |    74.151 μs |  0.6231 μs |  0.5203 μs |    74.035 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 8KB          |    75.221 μs |  0.6630 μs |  0.5877 μs |    75.318 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Decrypt · SEED-CBC (Managed)      | 128KB        | 1,175.743 μs |  9.9179 μs |  8.7920 μs | 1,174.382 μs |         - |
| Decrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,202.573 μs | 19.5993 μs | 15.3019 μs | 1,200.461 μs |     152 B |
|                                   |              |              |            |            |              |           |
| Encrypt · SEED-CBC (Managed)      | 128KB        | 1,188.818 μs | 16.6828 μs | 15.6051 μs | 1,182.123 μs |         - |
| Encrypt · SEED-CBC (BouncyCastle) | 128KB        | 1,205.264 μs | 11.7409 μs | 10.9825 μs | 1,207.808 μs |     152 B |