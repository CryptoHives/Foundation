| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · Managed      | 128B         |   2.753 μs | 0.0127 μs | 0.0112 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128B         |   4.061 μs | 0.0291 μs | 0.0258 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 1KB          |   4.505 μs | 0.0389 μs | 0.0325 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 1KB          |   5.992 μs | 0.0300 μs | 0.0251 μs |    1152 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 8KB          |  17.229 μs | 0.1648 μs | 0.1541 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 8KB          |  19.626 μs | 0.1289 μs | 0.1206 μs |    9216 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · Managed      | 128KB        | 236.420 μs | 1.5294 μs | 1.4306 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle | 128KB        | 257.728 μs | 1.4134 μs | 1.3221 μs |  149760 B |