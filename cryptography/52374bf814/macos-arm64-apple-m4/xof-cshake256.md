| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128B         |   2.509 μs | 0.0207 μs | 0.0183 μs |         - |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128B         |   2.759 μs | 0.0041 μs | 0.0037 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 1KB          |   3.658 μs | 0.0100 μs | 0.0094 μs |    1120 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 1KB          |   4.462 μs | 0.0092 μs | 0.0086 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 8KB          |  12.246 μs | 0.0198 μs | 0.0185 μs |    9600 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 8KB          |  17.661 μs | 0.0121 μs | 0.0101 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128KB        | 161.760 μs | 0.2484 μs | 0.2202 μs |  154080 B |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128KB        | 242.726 μs | 0.2304 μs | 0.2155 μs |         - |