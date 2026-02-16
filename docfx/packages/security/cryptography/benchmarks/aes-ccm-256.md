| Description                          | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|
| Decrypt · AES-256-CCM (Managed)      | 128B         |     1.276 μs |  0.0085 μs | 0.0071 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128B         |     2.038 μs |  0.0244 μs | 0.0216 μs |    3288 B |
|                                      |              |              |            |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128B         |     1.252 μs |  0.0117 μs | 0.0110 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128B         |     1.976 μs |  0.0259 μs | 0.0243 μs |    3328 B |
|                                      |              |              |            |           |           |
| Decrypt · AES-256-CCM (Managed)      | 1KB          |     8.225 μs |  0.0360 μs | 0.0301 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.227 μs |  0.0994 μs | 0.0930 μs |    5080 B |
|                                      |              |              |            |           |           |
| Encrypt · AES-256-CCM (Managed)      | 1KB          |     8.167 μs |  0.0803 μs | 0.0751 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 1KB          |    10.227 μs |  0.0853 μs | 0.0798 μs |    5120 B |
|                                      |              |              |            |           |           |
| Decrypt · AES-256-CCM (Managed)      | 8KB          |    63.704 μs |  0.6455 μs | 0.6038 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 8KB          |    75.802 μs |  0.7675 μs | 0.7179 μs |   19416 B |
|                                      |              |              |            |           |           |
| Encrypt · AES-256-CCM (Managed)      | 8KB          |    63.511 μs |  0.9380 μs | 0.8774 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 8KB          |    75.990 μs |  0.8947 μs | 0.8369 μs |   19456 B |
|                                      |              |              |            |           |           |
| Decrypt · AES-256-CCM (Managed)      | 128KB        | 1,010.866 μs |  9.0888 μs | 8.5017 μs |         - |
| Decrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,245.681 μs |  7.5142 μs | 7.0288 μs |  265204 B |
|                                      |              |              |            |           |           |
| Encrypt · AES-256-CCM (Managed)      | 128KB        | 1,013.201 μs |  5.3861 μs | 5.0382 μs |         - |
| Encrypt · AES-256-CCM (BouncyCastle) | 128KB        | 1,241.756 μs | 10.2855 μs | 9.6211 μs |  265244 B |