| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · Managed      | 128B         |   3.294 μs | 0.0375 μs | 0.0350 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128B         |   4.050 μs | 0.0657 μs | 0.0548 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128B         |   5.160 μs | 0.0347 μs | 0.0325 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · Managed      | 1KB          |   5.049 μs | 0.0451 μs | 0.0400 μs |         - |
| AbsorbSqueeze · KMAC-128 · OS Native    | 1KB          |   5.467 μs | 0.0407 μs | 0.0361 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 1KB          |   7.196 μs | 0.0541 μs | 0.0506 μs |    1280 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 8KB          |  15.919 μs | 0.1590 μs | 0.1328 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 8KB          |  17.989 μs | 0.1714 μs | 0.1603 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 8KB          |  21.169 μs | 0.1310 μs | 0.1225 μs |    9344 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · OS Native    | 128KB        | 196.669 μs | 1.8585 μs | 1.6475 μs |      32 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128KB        | 242.259 μs | 1.6483 μs | 1.4612 μs |         - |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128KB        | 267.527 μs | 2.7007 μs | 2.3941 μs |  149888 B |