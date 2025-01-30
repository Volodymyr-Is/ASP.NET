import React, { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [users, setUsers] = useState([]);
    const [formData, setFormData] = useState({ id: 0, name: '', age: '' });
    const [loading, setLoading] = useState(true);
    const API_URL = 'https://localhost:7191/api/user';

    useEffect(() => {
        fetchUsers();
    }, []);

    const fetchUsers = async () => {
        try {
            const response = await fetch(API_URL, {
                method: 'GET',
                headers: { 'Accept': 'application/json' }
            });
            if (response.ok) {
                const data = await response.json();
                setUsers(data);
            }
        } catch (error) {
            console.error('Failed to fetch users:', error);
        } finally {
            setLoading(false);
        }
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (formData.id === 0) {
            await createUser(formData.name, formData.age);
        } else {
            await updateUser(formData.id, formData.name, formData.age);
        }
        setFormData({ id: 0, name: '', age: '' });
    };

    const createUser = async (name, age) => {
        try {
            const response = await fetch(API_URL, {
                method: 'POST',
                headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
                body: JSON.stringify({ name, age: parseInt(age, 10) })
            });
            if (response.status === 201) {
                const newUser = await response.json();
                setUsers([...users, newUser]);
            }
        } catch (error) {
            console.error('Failed to create user:', error);
        }
    };

    const updateUser = async (id, name, age) => {
        try {
            const response = await fetch(`${API_URL}/${id}`, {
                method: 'PUT',
                headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
                body: JSON.stringify({ name, age: parseInt(age, 10) })
            });
            if (response.ok) {
                const updatedUser = await response.json();
                setUsers(users.map(user => (user.id === id ? updatedUser : user)));
            }
        } catch (error) {
            console.error('Failed to update user:', error);
        }
    };

    const deleteUser = async (id) => {
        try {
            const response = await fetch(`${API_URL}/${id}`, {
                method: 'DELETE',
                headers: { 'Accept': 'application/json' }
            });
            if (response.ok) {
                setUsers(users.filter(user => user.id !== id));
            }
        } catch (error) {
            console.error('Failed to delete user:', error);
        }
    };

    const handleEdit = (user) => {
        setFormData({ id: user.id, name: user.name, age: user.age });
    };

    if (loading) return <img src="/images/loading.gif" alt="Loading..." />;

    return (
        <div className="App">
            <form onSubmit={handleSubmit}>
                <input type="hidden" name="id" value={formData.id} />
                <div>
                    <label htmlFor="name">Name:</label>
                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        onChange={handleInputChange}
                    />
                </div>
                <div>
                    <label htmlFor="age">Age:</label>
                    <input
                        type="number"
                        name="age"
                        value={formData.age}
                        onChange={handleInputChange}
                    />
                </div>
                <button type="submit">Save</button>
            </form>

            <table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Age</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user => (
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.name}</td>
                            <td>{user.age}</td>
                            <td>
                                <button onClick={() => handleEdit(user)}>Edit</button>
                                <button onClick={() => deleteUser(user.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default App;
