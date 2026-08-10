| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · KMAC-256 · Managed      | 128B         |   3.702 μs | 0.0096 μs | 0.0080 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128B         |   4.533 μs | 0.0285 μs | 0.0267 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128B         |   5.843 μs | 0.0241 μs | 0.0226 μs |     128 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · Managed      | 1KB          |   5.599 μs | 0.0352 μs | 0.0312 μs |         - |
| AbsorbSqueeze · KMAC-256 · OS Native    | 1KB          |   6.158 μs | 0.0253 μs | 0.0212 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 1KB          |   8.060 μs | 0.0279 μs | 0.0247 μs |    1248 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 8KB          |  18.680 μs | 0.1356 μs | 0.1269 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 8KB          |  20.131 μs | 0.1130 μs | 0.1057 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 8KB          |  24.888 μs | 0.0869 μs | 0.0813 μs |    9728 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · KMAC-256 · OS Native    | 128KB        | 231.475 μs | 1.3978 μs | 1.3075 μs |      32 B |
| AbsorbSqueeze · KMAC-256 · Managed      | 128KB        | 268.190 μs | 1.9150 μs | 1.6976 μs |         - |
| AbsorbSqueeze · KMAC-256 · BouncyCastle | 128KB        | 315.668 μs | 1.7314 μs | 1.6196 μs |  154208 B |