| Description                                    | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128B         |   2.421 μs | 0.0038 μs | 0.0035 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128B         |   2.500 μs | 0.0054 μs | 0.0045 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128B         |   2.566 μs | 0.0063 μs | 0.0058 μs |         - |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   3.414 μs | 0.0023 μs | 0.0021 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 1KB          |   3.629 μs | 0.0024 μs | 0.0020 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 1KB          |   3.658 μs | 0.0071 μs | 0.0063 μs |    1120 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 8KB          |  10.891 μs | 0.0036 μs | 0.0033 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 8KB          |  11.643 μs | 0.0070 μs | 0.0054 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 8KB          |  12.292 μs | 0.0241 μs | 0.0225 μs |    9600 B |
|                                                |              |            |           |           |           |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 138.608 μs | 0.0688 μs | 0.0643 μs |         - |
| AbsorbSqueeze · cSHAKE256 · CryptoHives-Scalar | 128KB        | 148.507 μs | 0.1976 μs | 0.1650 μs |         - |
| AbsorbSqueeze · cSHAKE256 · BouncyCastle       | 128KB        | 159.624 μs | 0.2866 μs | 0.2541 μs |  154080 B |