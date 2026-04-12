| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · Managed      | 128B         |   3.770 μs | 0.0390 μs | 0.0346 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128B         |   4.599 μs | 0.0202 μs | 0.0179 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128B         |   5.905 μs | 0.0400 μs | 0.0354 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · Managed      | 1KB          |   5.654 μs | 0.0333 μs | 0.0311 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 1KB          |   6.244 μs | 0.0431 μs | 0.0382 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 1KB          |   8.137 μs | 0.0653 μs | 0.0579 μs |    1248 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 8KB          |  18.883 μs | 0.1348 μs | 0.1261 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 8KB          |  20.476 μs | 0.1815 μs | 0.1609 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 8KB          |  25.408 μs | 0.1718 μs | 0.1523 μs |    9728 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128KB        | 233.734 μs | 1.3195 μs | 1.1697 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128KB        | 271.973 μs | 2.4335 μs | 2.1573 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128KB        | 318.840 μs | 2.2413 μs | 2.0965 μs |  154208 B |