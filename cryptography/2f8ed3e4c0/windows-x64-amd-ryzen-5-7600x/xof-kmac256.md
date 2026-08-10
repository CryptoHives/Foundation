| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · Managed      | 128B         |   3.867 μs | 0.0370 μs | 0.0328 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128B         |   4.763 μs | 0.0459 μs | 0.0407 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128B         |   6.103 μs | 0.0519 μs | 0.0486 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · Managed      | 1KB          |   5.824 μs | 0.0503 μs | 0.0446 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 1KB          |   6.453 μs | 0.0809 μs | 0.0717 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 1KB          |   8.385 μs | 0.0548 μs | 0.0458 μs |    1248 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 8KB          |  19.273 μs | 0.1469 μs | 0.1302 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 8KB          |  20.938 μs | 0.2444 μs | 0.2286 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 8KB          |  25.787 μs | 0.2122 μs | 0.1985 μs |    9728 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128KB        | 238.920 μs | 1.8466 μs | 1.7274 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128KB        | 276.988 μs | 2.2135 μs | 1.9622 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128KB        | 328.022 μs | 2.8794 μs | 2.6934 μs |  154208 B |