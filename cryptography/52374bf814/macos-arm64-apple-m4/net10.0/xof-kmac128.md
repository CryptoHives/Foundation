| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128B         |   2.597 μs | 0.0069 μs | 0.0064 μs |     128 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128B         |   2.648 μs | 0.0037 μs | 0.0033 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 1KB          |   3.600 μs | 0.0089 μs | 0.0083 μs |    1280 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 1KB          |   4.205 μs | 0.0062 μs | 0.0058 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 8KB          |  10.587 μs | 0.0122 μs | 0.0108 μs |    9344 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 8KB          |  15.812 μs | 0.0223 μs | 0.0197 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-128 · BouncyCastle | 128KB        | 132.440 μs | 0.2612 μs | 0.2316 μs |  149888 B |
| AbsorbSqueeze · KMAC-128 · Managed      | 128KB        | 216.616 μs | 0.1450 μs | 0.1285 μs |         - |