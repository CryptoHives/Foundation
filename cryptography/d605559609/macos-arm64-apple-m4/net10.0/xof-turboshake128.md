| Description                                        | TestDataSize | Mean      | Error     | StdDev    | Median    | Allocated |
|--------------------------------------------------- |------------- |----------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Scalar | 128B         |  1.146 μs | 0.0022 μs | 0.0019 μs |  1.146 μs |         - |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Arm64  | 128B         |  1.189 μs | 0.0479 μs | 0.1405 μs |  1.105 μs |         - |
|                                                    |              |           |           |           |           |           |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Arm64  | 1KB          |  1.551 μs | 0.0196 μs | 0.0173 μs |  1.541 μs |         - |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Scalar | 1KB          |  1.638 μs | 0.0109 μs | 0.0097 μs |  1.644 μs |         - |
|                                                    |              |           |           |           |           |           |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Arm64  | 8KB          |  4.673 μs | 0.0032 μs | 0.0030 μs |  4.672 μs |         - |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Scalar | 8KB          |  4.931 μs | 0.0090 μs | 0.0084 μs |  4.927 μs |         - |
|                                                    |              |           |           |           |           |           |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Arm64  | 128KB        | 59.184 μs | 0.3861 μs | 0.3014 μs | 59.094 μs |         - |
| AbsorbSqueeze · TurboSHAKE128 · CryptoHives-Scalar | 128KB        | 62.778 μs | 0.1368 μs | 0.1212 μs | 62.761 μs |         - |