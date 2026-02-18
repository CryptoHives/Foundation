| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · Managed      | 128B         |   3.285 μs | 0.0201 μs | 0.0188 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128B         |   4.881 μs | 0.0168 μs | 0.0157 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 1KB          |   5.176 μs | 0.0203 μs | 0.0180 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 1KB          |   7.045 μs | 0.0211 μs | 0.0198 μs |    1120 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 8KB          |  19.910 μs | 0.3334 μs | 0.2784 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 8KB          |  23.971 μs | 0.0777 μs | 0.0689 μs |    9600 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128KB        | 268.838 μs | 1.0421 μs | 0.9238 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128KB        | 313.654 μs | 1.8091 μs | 1.6922 μs |  154080 B |