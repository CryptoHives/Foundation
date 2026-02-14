| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · Managed      | 128B         |   3.427 μs | 0.0293 μs | 0.0274 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128B         |   5.073 μs | 0.0357 μs | 0.0316 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 1KB          |   5.355 μs | 0.0328 μs | 0.0291 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 1KB          |   7.371 μs | 0.0416 μs | 0.0389 μs |    1120 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 8KB          |  20.462 μs | 0.1933 μs | 0.1714 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 8KB          |  25.064 μs | 0.1812 μs | 0.1695 μs |    9600 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128KB        | 277.657 μs | 2.9247 μs | 2.5927 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128KB        | 327.108 μs | 2.8319 μs | 2.6489 μs |  154080 B |