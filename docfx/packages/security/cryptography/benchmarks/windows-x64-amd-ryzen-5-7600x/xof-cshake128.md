| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128B         |   2.771 μs | 0.0147 μs | 0.0123 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128B         |   4.057 μs | 0.0173 μs | 0.0162 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 1KB          |   4.479 μs | 0.0302 μs | 0.0268 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 1KB          |   5.997 μs | 0.0348 μs | 0.0308 μs |    1152 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 8KB          |  17.140 μs | 0.0922 μs | 0.0817 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 8KB          |  19.437 μs | 0.1043 μs | 0.0975 μs |    9216 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE128 · CryptoHives-Scalar | 128KB        | 236.129 μs | 1.1667 μs | 1.0913 μs |         - |
| AbsorbSqueeze · cSHAKE128 · BouncyCastle       | 128KB        | 260.616 μs | 4.1441 μs | 4.0700 μs |  149760 B |