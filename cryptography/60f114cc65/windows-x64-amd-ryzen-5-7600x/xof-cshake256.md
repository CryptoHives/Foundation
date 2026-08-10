| Description                              | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · Managed      | 128B         |   3.364 μs | 0.0273 μs | 0.0242 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128B         |   4.943 μs | 0.0302 μs | 0.0252 μs |         - |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 1KB          |   5.244 μs | 0.0279 μs | 0.0247 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 1KB          |   7.181 μs | 0.0255 μs | 0.0238 μs |    1120 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 8KB          |  20.041 μs | 0.1374 μs | 0.1285 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 8KB          |  24.251 μs | 0.1592 μs | 0.1330 μs |    9600 B |
|                                          |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · Managed      | 128KB        | 272.119 μs | 2.1220 μs | 1.8811 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle | 128KB        | 315.981 μs | 2.2750 μs | 2.1280 μs |  154080 B |