| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · Managed      | 128B         |   2.836 μs | 0.0163 μs | 0.0136 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128B         |   4.156 μs | 0.0249 μs | 0.0221 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 1KB          |   4.606 μs | 0.0315 μs | 0.0295 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 1KB          |   6.181 μs | 0.0539 μs | 0.0478 μs |    1152 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 8KB          |  17.668 μs | 0.3276 μs | 0.3065 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 8KB          |  20.208 μs | 0.2379 μs | 0.2226 μs |    9216 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128KB        | 241.793 μs | 2.4495 μs | 2.1714 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128KB        | 267.440 μs | 4.3463 μs | 4.0655 μs |  149760 B |