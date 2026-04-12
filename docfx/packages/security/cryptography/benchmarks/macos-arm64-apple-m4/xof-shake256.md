| Description                             | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128B         |   2.509 μs | 0.0171 μs | 0.0160 μs |         - |
| AbsorbSqueeze · SHAKE256 · Managed      | 128B         |   2.758 μs | 0.0023 μs | 0.0019 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 1KB          |   3.653 μs | 0.0055 μs | 0.0051 μs |    1120 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 1KB          |   4.465 μs | 0.0026 μs | 0.0024 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 8KB          |  12.268 μs | 0.0185 μs | 0.0173 μs |    9600 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 8KB          |  17.670 μs | 0.0158 μs | 0.0140 μs |         - |
|                                         |              |            |           |           |           |
| AbsorbSqueeze · SHAKE256 · BouncyCastle | 128KB        | 159.175 μs | 0.2583 μs | 0.2416 μs |  154080 B |
| AbsorbSqueeze · SHAKE256 · Managed      | 128KB        | 242.821 μs | 0.1587 μs | 0.1407 μs |         - |