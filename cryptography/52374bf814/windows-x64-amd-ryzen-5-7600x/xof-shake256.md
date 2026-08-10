| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · Managed      | 128B         |   3.280 μs | 0.0152 μs | 0.0142 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128B         |   3.913 μs | 0.0268 μs | 0.0224 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128B         |   4.886 μs | 0.0312 μs | 0.0292 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · Managed      | 1KB          |   5.176 μs | 0.0270 μs | 0.0239 μs |         - |
| AbsorbSqueeze · SHAKE256 · OS Native    | 1KB          |   5.570 μs | 0.0395 μs | 0.0370 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 1KB          |   7.127 μs | 0.0228 μs | 0.0213 μs |    1120 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 8KB          |  17.977 μs | 0.0917 μs | 0.0813 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 8KB          |  19.717 μs | 0.1401 μs | 0.1311 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 8KB          |  24.041 μs | 0.1322 μs | 0.1236 μs |    9600 B |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · OS Native    | 128KB        | 230.806 μs | 1.2026 μs | 1.1249 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 128KB        | 267.690 μs | 1.6346 μs | 1.4490 μs |         - |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128KB        | 313.548 μs | 1.2497 μs | 1.1078 μs |  154080 B |