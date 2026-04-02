| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 128B         |   8.330 μs | 0.0546 μs | 0.0511 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 128B         |  11.889 μs | 0.0280 μs | 0.0262 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 1KB          |  11.640 μs | 0.0597 μs | 0.0529 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 1KB          |  16.615 μs | 0.0617 μs | 0.0547 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 8KB          |  38.525 μs | 0.1623 μs | 0.1439 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 8KB          |  55.357 μs | 0.6130 μs | 0.5434 μs |         - |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · Ascon-XOF128 · Managed      | 128KB        | 495.897 μs | 1.7416 μs | 1.5439 μs |         - |
| AbsorbSqueeze · Ascon-XOF128 · BouncyCastle | 128KB        | 718.204 μs | 3.4863 μs | 3.0905 μs |         - |